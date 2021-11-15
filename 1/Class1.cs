using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace _1
{
    [Table(Name = "Пункты")]
    public class Пункты
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Код_пункта { get; set; }
        [Column]
        public string Пункт_назначения { get; set; }
    }
    [Table(Name = "Рейсы")]
    public class Рейсы
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Код_рейса { get; set; }
        [Column]
        public int Пункт { get; set; }
        [Column]
        public int Дни { get; set; }
        [Column]
        public int Маршрут { get; set; }
        [Column]
        public int Автобус { get; set; }
        [Column]
        public int Цена_билета { get; set; }
       
    }
    [Table(Name = "Маршрут")]
    public class Маршрут
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Код_маршрута { get; set; }
        [Column]
        public string Пункт_отпр { get; set; }
        [Column]
        public string Пункт_приб { get; set; }
        
    }
    [Table(Name = "Автобусы")]
    public class Автобусы
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Код_автобуса { get; set; }
        [Column]
        public string Марка { get; set; }
        [Column]
        public int Номер { get; set; }
        [Column]
        public string Водитель { get; set; }
        [Column]
        public int Число_мест { get; set; }
    }
    
    
}
