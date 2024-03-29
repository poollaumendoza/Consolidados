﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class LlenadoContenedor
    {
        public int IdLlenadoContenedor { get; set; }
        public Contrato oContrato { get; set; }
        public ContratoContenedor oContratoContenedor { get; set; }
        public Lote oLote { get; set; }
        public int Cantidad { get; set; }
        public Estado oEstado { get; set; }
    }
}