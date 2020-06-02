using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Model
{

    public class Time : ITabela
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime dataCriacao { get; set; }
        public string corUniformePrincipal { get; set; }
        public string corUniformeSecundario { get; set; }



        public Time(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            this.id = id;
            this.name = name;
            dataCriacao = createDate;
            corUniformePrincipal = mainShirtColor;
            corUniformeSecundario = secondaryShirtColor;
        }
    }
}
