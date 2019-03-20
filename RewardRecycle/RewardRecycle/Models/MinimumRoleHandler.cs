using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;

namespace RewardRecycle.Models
{
    public class MinimumRoleHandler : AuthorizationHandler<RoleRequirement>
    {
        [System.Data.DataSysDescription("DbCommand_Parameters")]
        public System.Data.SqlClient.SqlParameterCollection Parameters { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var user = context.User;

            var name = user.Identity.Name;

            string queryString = "SELECT Name FROM AspNetRoles as ar JOIN AspNetUserRoles as ur ON ar.Id = ur.RoleId JOIN AspNetUsers as au ON ur.UserId = au.Id WHERE au.UserName = @UserName";
            //string queryString2 = "SELECT * FROM AspNetRoles";

            string connectionString = "Server=localhost;Database=RewardRecycle;User=root;Password=Blabla12!;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@UserName", MySqlDbType.VarChar);
                command.Parameters["@UserName"].Value = name;
                Console.WriteLine(command.Parameters);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);

                    MySqlDataReader myReader;
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        var myString = myReader.GetString(0);

                        if (myString.Equals("Admin"))
                        {
                            context.Succeed(requirement);
                        }
                    }
                    // always call Close when done reading.
                    myReader.Close();
                    // Close the connection when done with it.
                    connection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return Task.CompletedTask;
            }
        }
    }
}
