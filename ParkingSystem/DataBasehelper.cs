using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    public static class DataBasehelper
    {
        private static string connectionString =
            @"Data Source=" + Application.StartupPath + @"\parking.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string parkingTable = @"CREATE TABLE IF NOT EXISTS ParkingRecords (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        ParkingNumber TEXT,
                                        Plate TEXT,
                                        Type TEXT,
                                        EntryTime TEXT,
                                        ExitTime TEXT,
                                        Slot TEXT,
                                        Fee REAL
                                        );";

                string slotTable = @"CREATE TABLE IF NOT EXISTS ParkingSlots (
                                     SlotNumber TEXT PRIMARY KEY,
                                     IsOccupied INTEGER
                                     );";

                SQLiteCommand cmd = new SQLiteCommand(parkingTable, con);
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand(slotTable, con);
                cmd.ExecuteNonQuery();

                // Add Fee column to existing databases that don't have it yet
                try
                {
                    string addFeeCol = "ALTER TABLE ParkingRecords ADD COLUMN Fee REAL";
                    cmd = new SQLiteCommand(addFeeCol, con);
                    cmd.ExecuteNonQuery();
                }
                catch { /* Column already exists, ignore */ }
            }
        }

        public static void SeedSlots()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string[] slots = { "A1", "A2", "A3", "A4", "A5", "A6", "B1", "B2", "B3", "B4", "B5", "B6" };

                foreach (var slot in slots)
                {
                    string sql = "INSERT OR IGNORE INTO ParkingSlots (SlotNumber, IsOccupied) VALUES (@slot, 0)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // CHECK IF SLOT IS FREE
        public static bool IsSlotAvailable(string slot)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT IsOccupied FROM ParkingSlots WHERE SlotNumber=@slot";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@slot", slot);

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) == 0;
            }
        }

        // OCCUPY SLOT WHEN CAR ENTERS
        public static void OccupySlot(string slot)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string sql = "UPDATE ParkingSlots SET IsOccupied=1 WHERE SlotNumber=@slot";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@slot", slot);
                cmd.ExecuteNonQuery();
            }
        }

        public static void FreeSlot(string slot)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string sql = "UPDATE ParkingSlots SET IsOccupied=0 WHERE SlotNumber=@slot";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@slot", slot);
                cmd.ExecuteNonQuery();
            }
        }

        public static Dictionary<string, int> GetAllSlots()
        {
            var slots = new Dictionary<string, int>();

            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string sql = "SELECT SlotNumber, IsOccupied FROM ParkingSlots";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    slots.Add(reader["SlotNumber"].ToString(),
                              Convert.ToInt32(reader["IsOccupied"]));
                }
            }

            return slots;
        }

        public static void InsertParkingRecord(string parkingNo, string plate, string type, string entryTime, string slot, decimal fee)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string sql = @"INSERT INTO ParkingRecords
                       (ParkingNumber, Plate, Type, EntryTime, Slot, Fee)
                       VALUES (@no, @plate, @type, @entry, @slot, @fee)";

                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@no", parkingNo);
                cmd.Parameters.AddWithValue("@plate", plate);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@entry", entryTime);
                cmd.Parameters.AddWithValue("@slot", slot);
                cmd.Parameters.AddWithValue("@fee", fee);

                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetVehicleLogs()
        {
            DataTable dt = new DataTable();

            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"SELECT 
                ParkingNumber AS '#',
                Plate,
                Type,
                Slot,
                EntryTime AS 'Entry',
                ExitTime AS 'Exit',
                Fee AS 'Fee (₱)'
                FROM ParkingRecords
                ORDER BY Id DESC";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                da.Fill(dt);
            }

            return dt;
        }

        public static DataRow GetActiveRecordByPlate(string plate)
        {
            DataTable dt = new DataTable();

            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string sql = @"SELECT ParkingNumber, Plate, Type, Slot, EntryTime, ExitTime, Fee
                       FROM ParkingRecords 
                       WHERE Plate = @plate 
                       AND (ExitTime IS NULL OR ExitTime = '')
                       LIMIT 1";

                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@plate", plate);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool ProcessExit(string plate, string exitTime, decimal fee)
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Get slot first so we can free it
                        string getSlot = @"SELECT Slot FROM ParkingRecords 
                                   WHERE Plate = @plate 
                                   AND (ExitTime IS NULL OR ExitTime = '')";
                        SQLiteCommand getCmd = new SQLiteCommand(getSlot, con);
                        getCmd.Parameters.AddWithValue("@plate", plate);
                        string slot = getCmd.ExecuteScalar()?.ToString();

                        // 2. Set exit time AND the calculated Fee
                        string sql = @"UPDATE ParkingRecords 
                               SET ExitTime = @exit, Fee = @fee
                               WHERE Plate = @plate 
                               AND (ExitTime IS NULL OR ExitTime = '')";

                        SQLiteCommand cmd = new SQLiteCommand(sql, con);
                        cmd.Parameters.AddWithValue("@exit", exitTime);
                        cmd.Parameters.AddWithValue("@fee", fee); // Saves the exact amount
                        cmd.Parameters.AddWithValue("@plate", plate);
                        cmd.ExecuteNonQuery();

                        // 3. Free the slot
                        if (!string.IsNullOrEmpty(slot))
                        {
                            string sqlFree = "UPDATE ParkingSlots SET IsOccupied=0 WHERE SlotNumber=@slot";
                            SQLiteCommand cmdFree = new SQLiteCommand(sqlFree, con);
                            cmdFree.Parameters.AddWithValue("@slot", slot);
                            cmdFree.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public static decimal CalculateFee(string vehicleType)
        {
            switch (vehicleType)
            {
                case "2 Wheeler": return 20;
                case "4 Wheeler": return 40;
                case "6 Wheeler": return 60;
                default: return 0;
            }
        }

        public static int GetOccupiedCount()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM ParkingSlots WHERE IsOccupied = 1";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int GetAvailableCount()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM ParkingSlots WHERE IsOccupied = 0";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static decimal GetTodaysIncome()
        {
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string today = DateTime.Now.ToString("MM/dd/yyyy");
                string sql = @"SELECT IFNULL(SUM(Fee), 0) FROM ParkingRecords 
                       WHERE EntryTime LIKE @today";
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.AddWithValue("@today", today + "%");
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public static DataTable GetRecentTransactions()
        {
            DataTable dt = new DataTable();

            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"SELECT 
            ParkingNumber AS '#',
            Plate,
            Slot,
            Fee,
            CASE 
                WHEN ExitTime IS NULL OR ExitTime = '' THEN 'Active'
                ELSE 'Exited'
            END AS Status
            FROM ParkingRecords
            ORDER BY Id DESC
            LIMIT 50";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                da.Fill(dt);
            }

            return dt;


        }

        public static bool DeleteTransaction(string parkingNumber)
        {
            using (var con = GetConnection())
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Get the slot associated with this record before deleting
                        string getSlotSql = "SELECT Slot FROM ParkingRecords WHERE ParkingNumber = @no";
                        string slot = "";
                        using (var cmdGet = new SQLiteCommand(getSlotSql, con))
                        {
                            cmdGet.Parameters.AddWithValue("@no", parkingNumber);
                            slot = cmdGet.ExecuteScalar()?.ToString();
                        }

                        // 2. Delete the record
                        string deleteSql = "DELETE FROM ParkingRecords WHERE ParkingNumber = @no";
                        using (var cmdDel = new SQLiteCommand(deleteSql, con))
                        {
                            cmdDel.Parameters.AddWithValue("@no", parkingNumber);
                            cmdDel.ExecuteNonQuery();
                        }

                        // 3. If a slot was found, mark it as available (just in case it was an 'Active' record)
                        if (!string.IsNullOrEmpty(slot))
                        {
                            string updateSlotSql = "UPDATE ParkingSlots SET IsOccupied = 0 WHERE SlotNumber = @slot";
                            using (var cmdSlot = new SQLiteCommand(updateSlotSql, con))
                            {
                                cmdSlot.Parameters.AddWithValue("@slot", slot);
                                cmdSlot.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }

        }
    }
}
