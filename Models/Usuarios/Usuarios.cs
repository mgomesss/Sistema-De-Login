namespace SistemaDeVendas.Models.Usuarios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class Usuarios
    {
        [Key]
        public int Id_Usuario { get; set; }

        [StringLength(50)]
        public string NomeUsuario { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        public bool? Bloqueio { get; set; }

        public int? FK_Grupo { get; set; }

        public DateTime? Dt_Criacao { get; set; }

        public DateTime? Dt_AlteracaoSenha { get; set; }

        public DateTime? Dt_Bloqueio { get; set; }


        public bool Login()
        {
            var result = false;
            var sql = "SELECT * FROM Usuarios WHERE Email = '" + this.Email + " ' ";

            try
            {
                using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SystemSell"].ToString()))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    if (this.Senha == dr["Senha"].ToString().Trim())
                                    {
                                        this.Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]);
                                        this.NomeUsuario = dr["NomeUsuario"].ToString();
                                        this.Bloqueio = Convert.ToBoolean(dr["Bloqueio"]);
                                        this.FK_Grupo = Convert.ToInt32(dr["FK_Grupo"]);
                                        this.Dt_Criacao = Convert.ToDateTime(dr["Dt_Criacao"]);
                                        this.Dt_AlteracaoSenha = Convert.ToDateTime(dr["Dt_AlteracaoSenha"]);
                                        this.Dt_Bloqueio = Convert.ToDateTime(dr["Dt_Bloqueio"]);
                                        
                                        result = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}

