using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZE.Repositories
{
    public class BorrowEquipmentsClassRepository
    {
        private static BorrowEquipmentsClassRepository instance = null;
        private string cnUrl;

        private BorrowEquipmentsClassRepository(string cnUrl)
        {
            this.cnUrl = cnUrl;
        }

        public static BorrowEquipmentsClassRepository getInstance(string cnUrl)
        {
            if (instance == null)
            {
                instance = new BorrowEquipmentsClassRepository(cnUrl);
            }
            return instance;
        }

        public void updateStatusBorrowEquipmentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(cnUrl))
            {
                conn.Open();
                var query = "UPDATE BorrowEquipmentsTable SET Status='VERIFIED' WHERE ID=" + id;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<BorrowEquipmentsClass> getBorrowEquipmentsByStatus(string status)
        {
            List<BorrowEquipmentsClass> borrows = new List<BorrowEquipmentsClass>();
            using (SqlConnection conn = new SqlConnection(cnUrl))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM BorrowEquipmentsTable WHERE Status='" + status + "'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int id = Convert.ToInt32(dr["ID"]);
                                string studentNumber = dr["Student_Number"].ToString();
                                string borrower = dr["Borrower"].ToString();
                                string yearAndSection = dr["Year_and_Section"].ToString();
                                string equipmentBorrowed = dr["Equipment_Borrowed"].ToString();
                                string equipmentBarcode = dr["Equipment_Barcode"].ToString();
                                string timeAndDateBorrowed = dr["Time_and_Date_Borrowed"].ToString();
                                string professor = dr["Professor"].ToString();
                                string tCode = dr["Code"].ToString();
                                string personInCharge = dr["Person_in_Charge"].ToString();
                                string tStatus = dr["Status"].ToString();
                                string studentContactNumber = dr["Status"].ToString();
                                BorrowEquipmentsClass borrowEquipmentsClass = new BorrowEquipmentsClass() { ID = id, Borrower = borrower, Code = tCode, Equipment_Barcode = equipmentBarcode, Equipment_Borrowed = equipmentBarcode, Person_in_Charge = personInCharge, Professor = professor, Status = tStatus, Student_Contact_Number = studentContactNumber, Student_Number = studentNumber, Time_and_Date_Borrowed = timeAndDateBorrowed, Year_and_Section = yearAndSection };
                                borrows.Add(borrowEquipmentsClass);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cant fetch Borrow Transactions from database");
                    Console.WriteLine(ex);
                }
            }
            return borrows;
        }
    }
}