using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var cn = new SqlConnection("Server=tcp:ibisticdockerexample.database.windows.net,1433;Initial Catalog=docker;Persist Security Info=False;User ID=docker;Password=Mercell0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = "SELECT @@VERSION" })
                {
                    try
                    {
                        cn.Open();

                        var reader = cmd.ExecuteReader();
                        reader.Read();
                        Message = reader.GetString(0);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
