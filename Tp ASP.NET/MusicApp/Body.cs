using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public partial class Body : Component
    {
        public Body()
        {
            InitializeComponent();
        }

        public Body(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
