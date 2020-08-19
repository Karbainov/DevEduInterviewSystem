using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    abstract public class AbstractCRUD<T> where T : IDTO
    {
        public SqlConnection Connection { get; set; }
        //public InterviewsNumber InterviewsLimit { get; set; }
        public AbstractCRUD()
        {
            Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            //InterviewsLimit = new InterviewsNumber(InterviewsNumber.GetInstance().InterviewsLimit);
        }
        abstract public int Add(T dto);
        abstract public int DeleteByID(int id);
        abstract public int UpdateByID(T dto);
        abstract public List<T> SelectAll();
        abstract public T SelectByID(int id);
       
        protected SqlCommand ReferenceToProcedure(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
