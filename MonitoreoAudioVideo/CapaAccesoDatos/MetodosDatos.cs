using System;
using System.Collections.Generic;
using System.Data;
using AdminAudioVideo.Properties;
using Oracle.DataAccess.Client;

namespace AdminAudioVideo.CapaAccesoDatos
{
    class MetodosDatos
    {
        private readonly config _config = new config();
        private OracleConnection _conec;

        private void CrearConexion()
        {
            try
            {
                _conec = new OracleConnection(_config.connOracle);
                _conec.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CerrarConexion()
        {
            if(_conec.State != ConnectionState.Closed)
                _conec.Close();

        }

        public List<Sucursal> ObtenerSucursales(string idLaboratorio)
        {
            List<Sucursal> sucursales = null;
            CrearConexion();
            
            try
            {
                sucursales = new List<Sucursal>();
                OracleCommand query = new OracleCommand("SELECT B.ID, B.CLAVE, B.DENOMINACION " +
                                                        "FROM SUBUNIDADORGANIZACIONAL A JOIN UNIDADORGANIZACIONAL B" +
                                                        " ON B.ID = A.IDHIJO WHERE IDPADRE = :IDLABORATORIO" +
                                                        " ORDER BY B.CLAVE", _conec);
                query.Parameters.Add("IDLABORATORIOS", OracleDbType.Varchar2).Value = idLaboratorio;
                OracleDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Sucursal tmp = new Sucursal
                        {
                            IdSucursal = Int32.Parse(reader["ID"].ToString()),
                            ClaveSucursal = reader["CLAVE"].ToString(),
                            Descripcion = reader["DENOMINACION"].ToString()
                        };
                    sucursales.Add(tmp);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.WriteLine("StackTrace: {0}", ex.StackTrace);
            }
            finally
            {
                CerrarConexion();
            }
            return sucursales;
        }
    }
}
