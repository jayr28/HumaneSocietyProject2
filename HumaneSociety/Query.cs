using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
       
        internal static void RunEmployeeQueries(Employee employee, string v)
        {
            throw new NotImplementedException();
        }

        internal static Room GetRoom(int animalId)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<Animal> SearchForAnimalByMultipleTraits()
        {
            throw new NotImplementedException();
        }

        internal static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        internal static object GetAnimalByID(int iD)
        {
            throw new NotImplementedException();
        }

        internal static Client GetClient(string userName, string password)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<Animal> GetUserAdoptionStatus(Client client)
        {
            throw new NotImplementedException();
        }


        internal static List<Adoption> GetPendingAdoptions()
        {
            List<Adoption> adaptionList = new List<Adoption>();
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=HumaneSociety;Integrated Security=SSPI"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetPendingAdoptionsSP", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                //cmd.Parameters.Add(new SqlParameter("@UserId", userId));

                // execute the command

                Adoption adapt = new Adoption();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        //Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);

                        adapt.ApprovalStatus = rdr["ApprovalStatus"].ToString();
                        adapt.PaymentCollected = Convert.ToBoolean(rdr["PaymentCollected"]);
                        adaptionList.Add(adapt);
                    }
                }
                
            }
            return adaptionList;

        }

    }
}
