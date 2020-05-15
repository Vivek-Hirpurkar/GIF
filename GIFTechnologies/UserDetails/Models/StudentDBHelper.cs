using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserDetails.Models
{
    public class StudentDBHelper
    {
        public List<StudentDetails> GetAllStudents()
        {
            List<StudentDetails> students = new List<StudentDetails>();

            string cs = ConfigurationManager.ConnectionStrings["GIFDBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("uspGetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StudentDetails student = new StudentDetails();
                    student.StudentId = (int)reader["StudentId"];
                    student.StudentFirstName = reader["StudentFirstName"].ToString();
                    student.StudentLastName = reader["StudentLastName"].ToString();
                    student.Active = (bool)reader["Active"];

                    student.ParentId = (int)reader["ParentId"];
                    student.ParentFirstName = reader["ParentFirstName"].ToString();
                    student.ParentLastName = reader["ParentLastName"].ToString();
                    student.ParentEmail = reader["ParentEmail"].ToString();
                    student.ParentMobile = reader["ParentMobile"].ToString();

                    student.ClassId = (int)reader["ClassId"];
                    student.ClassName = reader["ClassName"].ToString();

                    students.Add(student);
                }
            }
            return students;
        }


        //To fetch Student by details
        public StudentDetails GetStudentDetailsById(int studentId)
        {
            StudentDetails student = new StudentDetails();

            string cs = ConfigurationManager.ConnectionStrings["GIFDBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_GetStudentDetailsById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", studentId);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student.StudentId = (int)reader["StudentId"];
                    student.StudentFirstName = reader["StudentFirstName"].ToString();
                    student.StudentLastName = reader["StudentLastName"].ToString();
                    student.Active = (bool)reader["Active"];

                    student.ParentId = (int)reader["ParentId"];
                    student.ParentFirstName = reader["ParentFirstName"].ToString();
                    student.ParentLastName = reader["ParentLastName"].ToString();
                    student.ParentEmail = reader["ParentEmail"].ToString();
                    student.ParentMobile = reader["ParentMobile"].ToString();

                    student.ClassId = (int)reader["ClassId"];
                    student.ClassName = reader["ClassName"].ToString();
                }
                if (reader.NextResult())
                {
                    student.SchoolClass = new List<SchoolClass>();

                    while (reader.Read())
                    {
                        SchoolClass sc = new SchoolClass();
                        sc.Id = (int)reader["Id"];
                        sc.Name = reader["Name"].ToString();

                        student.SchoolClass.Add(sc);
                    }
                }
            }
            return student;
        }


        //Update Student Details
        public void UpdateStudentDetails(StudentDetails student)
        {
            string cs = ConfigurationManager.ConnectionStrings["GIFDBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@StudentFirstName", student.StudentFirstName);
                cmd.Parameters.AddWithValue("@StudentLastName", student.StudentLastName);
                cmd.Parameters.AddWithValue("@ParentId", student.ParentId);
                cmd.Parameters.AddWithValue("@ParentEmail", student.ParentEmail);
                cmd.Parameters.AddWithValue("@ParentMobile", student.ParentMobile);
                cmd.Parameters.AddWithValue("@ClassId", student.ClassId);
                cmd.Parameters.AddWithValue("@Active", student.Active);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}