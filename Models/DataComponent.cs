using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using BoutiqueShop.Models;

namespace Boutiquedress.Models
{
    public class DataComponent
    {
        static string CONNECTIONSTRING = @"Data Source=LAPTOP-ILC2B3K2;Initial Catalog=Boutiquedress;User ID=sa;Password=sa123";

        public List<Dress> GetAllDresses()
        {
            var list = new List<Dress>();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    var query = "SELECT * FROM boutiquedress";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var dress = new Dress();
                        dress.DressID = Convert.ToInt32(reader[0]);
                        dress.DressName = reader[1].ToString();
                        dress.DressPrice = reader[2].ToString();
                        dress.ShopId = Convert.ToInt32(reader[3]);
                        list.Add(dress);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return list;
            }
        }

        public void AddNewDress(Dress dress)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = "INSERT INTO boutiquedress VALUES(@id,@name,@DressPrice,@ShopId)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", dress.DressID);
                cmd.Parameters.AddWithValue("@name", dress.DressName);
                cmd.Parameters.AddWithValue("@DressPrice", dress.DressPrice);
                cmd.Parameters.AddWithValue("@ShopId", dress.ShopId);
                try
                {

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("Details not added!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public Dress FindDress(int id)
        {
            Dress dress = new Dress();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM boutiquedress WHERE DressId =  " + id;
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        dress.DressID = Convert.ToInt32(reader[0]);
                        dress.DressName = reader[1].ToString();
                        dress.DressPrice = reader[2].ToString();                        
                        dress.ShopId = Convert.ToInt32(reader[3]);
                    }
                    else
                        throw new Exception("Dress not found!");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
                return dress;
            }
        }
        public void UpdateDress(Dress dress)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"UPDATE boutiquedress set DressName = '{ dress.DressName }', Actor = '{dress.DressPrice}', " +
                    $"" +
                    $" WHERE DressId = {dress.DressID}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void DeleteDress(int id)
        {
            Dress dress = new Dress();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM boutiquedress WHERE DressId = " + id;
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 0)
                        throw new Exception("Cannot Delete Dress");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}