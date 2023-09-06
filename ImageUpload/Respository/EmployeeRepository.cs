using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageUpload.Respository
{
    public class EmployeeRepository
    {
        private SqlConnection connection;
        private void Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();
            connection = new SqlConnection(connString);
        }
       
        public bool Insert(ImageModel obj, HttpPostedFileBase image)
        {
            Connection();
            using (SqlCommand command = new SqlCommand("SPI_StudentDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Address", obj.Address);
                byte[] PhotoBytes = ConvertToBytes(image);
                command.Parameters.AddWithValue("@Photo", PhotoBytes);
                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
        }
        public List<ImageModel> GetStudents()
        {
            Connection();
            List<ImageModel> studentsList = new List<ImageModel>();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_StudentDetail";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dtable = new DataTable();

            connection.Open();
            adapter.Fill(dtable);
            connection.Close();

            foreach (DataRow row in dtable.Rows)
            {
                studentsList.Add(new ImageModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    Photo = row["Photo"] as byte[]

                });
            }

            return studentsList;
        }
        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            if (image != null)
            {
                byte[] imageBytes = new byte[image.ContentLength];
                image.InputStream.Read(imageBytes, 0, image.ContentLength);
                return imageBytes;
            }
            return null;
        }





    }

}



       