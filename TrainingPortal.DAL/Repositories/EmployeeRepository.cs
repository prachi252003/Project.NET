using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TrainingPortal.DAL.DBUtility;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;
using TrainingPortal.Exceptions;
using TrainingPortal.Exceptions.CustomExceptions;


namespace TrainingPortal.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbHelper dbHelper;

        public EmployeeRepository()
        {
            dbHelper = new DbHelper();
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();
                SqlCommand cmd =
    new SqlCommand("AddEmployee", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteEmployee(int empId)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("DeleteEmployee", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new EmployeeNotFoundException();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public List<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("GetAllEmployees", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader =
                cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee();

                    emp.EmpId = Convert.ToInt32(reader["EmpId"]);
                    emp.Name = reader["Name"].ToString();
                    emp.Designation = reader["Designation"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.Phone = reader["Phone"].ToString();

                    employees.Add(emp);
                }

                con.Close();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeeById(int empId)
        {
            try
            {
                Employee emp = null;

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("GetEmployeeById", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp = new Employee();

                    emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                }

                con.Close();

                if (emp == null)
                    throw new EmployeeNotFoundException();

                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("UpdateEmployee", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new EmployeeNotFoundException();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}