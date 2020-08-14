using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class OneTimePasswordCRUD : AbstractCRUD<OneTimePasswordDTO>
    {
        public override int Add(OneTimePasswordDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddOneTimePassword");

            SqlParameter TypeOfRoleParam = new SqlParameter("@TypeOfRole", dto.TypeOfRole);
            command.Parameters.Add(TypeOfRoleParam);

            command.ExecuteNonQuery();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Role]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public override List<OneTimePasswordDTO> SelectAll()
        {
            throw new NotImplementedException();
        }

        public override OneTimePasswordDTO SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public override int UpdateByID(OneTimePasswordDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
