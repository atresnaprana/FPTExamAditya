using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FPTExam.Models
{
    public class ArtistDAL
    {
        string connectionString = "Data Source=ADITYA\\SQLEXPRESS; initial catalog=dbmusic; integrated security=True;";
        public IEnumerable<ArtistModel> GetArtist()  
        {
            List<ArtistModel> artistList = new List<ArtistModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetArtists", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ArtistModel fld = new ArtistModel();
                    fld.ArtistID = Convert.ToInt32(dr["ArtistID"].ToString());
                    fld.ArtistName = dr["ArtistName"].ToString();
                    fld.AlbumName = dr["AlbumName"].ToString();
                    fld.ImageUrl = dr["ImageUrl"].ToString();
                    fld.ArtistName = dr["ArtistName"].ToString();
                    fld.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"].ToString());
                    fld.SampleUrl = dr["SampleUrl"].ToString();
                    fld.Price = Convert.ToDouble(dr["Price"].ToString());
                    artistList.Add(fld);
                }
                con.Close();
            }
            return artistList;
        }
        public void addArtist(ArtistModel fld)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertArtist ", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArtistName", fld.ArtistName);
                cmd.Parameters.AddWithValue("@AlbumName", fld.AlbumName);
                cmd.Parameters.AddWithValue("@ImageUrl", fld.ImageUrl);

                cmd.Parameters.AddWithValue("@ReleaseDate", fld.ReleaseDate);
                cmd.Parameters.AddWithValue("@Price", fld.Price);
                cmd.Parameters.AddWithValue("@SampleUrl", fld.SampleUrl);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void updateArtist(ArtistModel fld)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateArtist ", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", fld.ArtistID);
                cmd.Parameters.AddWithValue("@ArtistName", fld.ArtistName);
                cmd.Parameters.AddWithValue("@AlbumName", fld.AlbumName);
                cmd.Parameters.AddWithValue("@ImageUrl", fld.ImageUrl);
                cmd.Parameters.AddWithValue("@ReleaseDate", fld.ReleaseDate);
                cmd.Parameters.AddWithValue("@Price", fld.Price);
                cmd.Parameters.AddWithValue("@SampleUrl", fld.SampleUrl);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void deleteArtist(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteArtist", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ArtistModel GetArtistById(int? ID)
        {
            ArtistModel artistList = new ArtistModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetArtistsByID ", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    artistList.ArtistID = Convert.ToInt32(dr["ArtistID"].ToString());
                    artistList.ArtistName = dr["ArtistName"].ToString();
                    artistList.AlbumName = dr["AlbumName"].ToString();
                    artistList.ImageUrl = dr["ImageUrl"].ToString();
                    artistList.ArtistName = dr["ArtistName"].ToString();
                    artistList.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"].ToString());
                    artistList.SampleUrl = dr["SampleUrl"].ToString();
                    artistList.Price = Convert.ToDouble(dr["Price"].ToString());
                }
                con.Close();
            }
            return artistList;
        }
    }
}
