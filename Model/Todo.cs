using BlazorLearning.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLearning.Model
{
    public class Todo
    {
        #region Explicando sobre atributos -> [] <-
        //Naturalmente não colocamos nada de atributos aqui e sim na hora de criar o banco, mas pra fins didatico ta ai
        /*
        Caso eu queira colocar um nome que não tenha Id porém eu quero que aquele campo seja o Id eu faço o seguinte
        Eu adiciono o '[Key]', assim o EF vai identificar que é uma chave primaria ja que nao estamos passando Id no nome

        [Key]
        public int OutroNome { get; set; }

        */

        //-----------------------------------------------------------------------------------

        /*
         Posso tambem informar que um campo é required aqui ao inves da classe do database

        [Required
         public DateTime CreationDate { get; set; }
         
         */

        #endregion
        public int Id { get; set; } //-> Posso colocar qualquer nome porém tem que ter Id no final(exemplo: TodoId, CampoId) assim o banco de dados identifica que o primeiro campo é o ID
        public DateTime CreationDate { get; set; }
        public TodoPriority Priority { get; set; }
        public string? Title { get; set; } //-> informando que ela pode ser nula
        // public string Title { get; set; } = ""; //-> inicializando vazio
        public string? Description { get; set; }
        public bool Done { get; set; }
        //public DateTime DoneCreate { get; set; } = DateTime.MinValue; //-> inicializando com o valor minimo de data (01/01/0001 00:00:00)
        public DateTime? DoneCreate { get; set; } //-> ? vai deixar null no banco se nao for passado

        //Fazendo relacionamento de tabelas Todo e Category
        //Coloquei CategoryId para o EF entender que é uma chave estrangeira pois o model chama Category
        //coloquei como int pois o Id da tabela Category é um int
        //eu crio duas propriedades, uma para o EF entender que é uma chave estrangeira(CategoryId) e outra para o relacionamento(Category)
        //Aqui vai ser criado um relacionamento do tipo <1 todo pode ter 1 categoria> e <1 categoria pode ter varios todo> (1 pra muitos)
        public int CategoryId { get; set; }
        public Category? Category { get; set; } //-> nullable pois pode ter um todo sem categoria

        [NotMapped] //-> não vai para o banco de dados
        public bool Edit { get; set; }

        #region Informações importantes        
        // A partir da versão 10 do c# as strings passaram a ser tratadas como um int, agora a partir dessa versão eu preciso tratar o nullable (olhe o Title)
        #endregion
    }
}
