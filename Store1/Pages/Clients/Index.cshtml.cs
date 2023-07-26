using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Store1.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
       
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Store1;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql,connection)) 
                    {
                     using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.id = "" + reader.GetInt32(0);


                            }
                        }
                     
                    }
                 }

            }
            catch (Exception ex)
            {

            }
        }
    }
    public class ClientInfo {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
    }
    

}
