using ClassificacaoCarros.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassificacaoCarros.Model
{
    public class garagem
    {
        public int id { get; set; }
        public int idMarca { get; set; }
        public string modelo { get; set; }
        public int idFabricante{ get; set; }
        public int idTipo { get; set; }
        public int ano { get; set; }
        public int idCombustivel { get; set; }
        public string cor { get; set; }
        public int chassi { get; set; }
        public int km { get; set; }
        public bool revisao { get; set; }
        public bool sinistro { get; set; }
        public bool roubo_furto { get; set; }
        public bool aluguel { get; set; }
        public bool venda { get; set; }
        public bool particular { get; set; }
        public string obs { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO garagem (idMarca, modelo, idFabricante, idTipo, ano, idCombustivel, cor, chassi, km, revisao, sinistro, roubo_furto, aluguel, venda, particular, obs) " +
                    "VALUES (@idMarca, @modelo, @idFabricante, @idTipo, @ano, @idCombustivel, @cor, @chassi, @km, @revisao, @sinistro, @roubo_furto, @aluguel, @venda, @particular, @obs)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@modelo", modelo);
                Banco.Comando.Parameters.AddWithValue("@idFabricante", idFabricante);
                Banco.Comando.Parameters.AddWithValue("@idTipo", idTipo);
                Banco.Comando.Parameters.AddWithValue("@ano", ano);
                Banco.Comando.Parameters.AddWithValue("@idCombustivel", idCombustivel);
                Banco.Comando.Parameters.AddWithValue("@cor", cor);
                Banco.Comando.Parameters.AddWithValue("@chassi", chassi);
                Banco.Comando.Parameters.AddWithValue("@km", km);
                Banco.Comando.Parameters.AddWithValue("@revisao", revisao);
                Banco.Comando.Parameters.AddWithValue("@sinistro", sinistro);
                Banco.Comando.Parameters.AddWithValue("@roubo_furto", roubo_furto);
                Banco.Comando.Parameters.AddWithValue("@aluguel", aluguel);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.Parameters.AddWithValue("@particular", particular);
                Banco.Comando.Parameters.AddWithValue("@obs", obs);



                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE garagem SET (idMarca = @idMarca, model = @modelo, idFabricante = @idFabricante, idTipo = @idTipo, ano = @ano, idCombustivel = @idCombustivel, cor = @cor, chassi = @chassi, km = @km, revisao = @revisao, sinistro = @sinistro, roubo_furto = @roubo_furto, alguel = @aluguel, venda = @venda, particular = @particular, obs = @obs WHERE id = @id )", Banco.Conexao);


                Banco.Comando.Parameters.AddWithValue("@idMarca", idMarca);
                Banco.Comando.Parameters.AddWithValue("@modelo", modelo);
                Banco.Comando.Parameters.AddWithValue("@idFabricante", idFabricante);
                Banco.Comando.Parameters.AddWithValue("@idTipo", idTipo);
                Banco.Comando.Parameters.AddWithValue("@ano", ano);
                Banco.Comando.Parameters.AddWithValue("@idCombustivel", idCombustivel);
                Banco.Comando.Parameters.AddWithValue("@cor", cor);
                Banco.Comando.Parameters.AddWithValue("@chassi", chassi);
                Banco.Comando.Parameters.AddWithValue("@km", km);
                Banco.Comando.Parameters.AddWithValue("@revisao", revisao);
                Banco.Comando.Parameters.AddWithValue("@sinistro", sinistro);
                Banco.Comando.Parameters.AddWithValue("@roubo_furto", roubo_furto);
                Banco.Comando.Parameters.AddWithValue("@aluguel", aluguel);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.Parameters.AddWithValue("@particular", particular);
                Banco.Comando.Parameters.AddWithValue("@obs", obs);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM garagem WHERE id=@id", Banco.Conexao);


                Banco.Comando.Parameters.AddWithValue("@id", id);


                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT ga.*, ma.descricao marca," +
                    "FROM garagem ga inner join marca ma on (ma.id = ga.idMarca)" +
                    "where ga.modelo like ?modelo order by ga.modelo", Banco.Conexao);

                Banco.Comando = new MySqlCommand("SELECT ga.*, fa.nome fabricante," +
                   "FROM garagem ga inner join fabricante fa on (fa.id = ga.idFabricante)" +
                   "where ga.modelo like ?modelo order by ga.modelo", Banco.Conexao);

                Banco.Comando = new MySqlCommand("SELECT ga.*, ti.descricao tipo," +
                   "FROM garagem ga inner join tipo ti on (ti.id = ga.idTipo)" +
                   "where ga.modelo like ?modelo order by ga.modelo", Banco.Conexao);

                Banco.Comando = new MySqlCommand("SELECT ga.*, co.descricao combustivel," +
                   "FROM garagem ga inner join combustivel co on (co.id = ga.idCombustivel)" +
                   "where ga.modelo like ?modelo order by ga.modelo", Banco.Conexao);


                Banco.Comando.Parameters.AddWithValue("@modelo", modelo + "%");

           
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
                return Banco.datTabela;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }
    }
}

