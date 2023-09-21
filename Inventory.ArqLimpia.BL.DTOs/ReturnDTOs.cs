using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ArqLimpia.BL.DTOs
{
    public class ReturnDTOs
    {
        //DTOs para crear retorno//
        public class createReturnInputDTO
        {
            [Required]
            public int IdUser { get; set; }
            
            public DateTime ReturnDAte { get; set; }
            [Required]
            public int IdStore { get; set; }
            [Required]
            public int IdProduct { get; set; }
        }

        public class createReturnOutputDTO
        {
            public int IdUser { get; set; }

            public DateTime ReturnDAte { get; set; }

            public int IdStore { get; set; }

            public int IdProduct { get; set; }
        }
        //DTo para buscar datos  un retorno
        public class findReturnInputDTO
        {
            [Required]
            public int IdStore { get; set; }


        }
        //Datos que devolvera un retorno 

        public class findReturnOutputDTO
        {
            public int IdUser { get; set; }

            public DateTime ReturnDAte { get; set; }

            public int IdStore { get; set; }

            public int IdProduct { get; set; }

            public  int IdReturn { get; set; }


        }
        //DTo para hacer  la entrada para cancelar el retorno
        public class cancelReturnInputDTO
        {
            [Required]
            public int IdReturn{ get; set; }


        }

        //DTO de los datos que mostrara  el retorno 
        public class cancelReturnOutputDTO
        {
            public bool status  { get; set; }
        }




    }
}


