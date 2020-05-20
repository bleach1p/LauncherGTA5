using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Launcher
{
    public class BatCheckerThread
    {
        private Process _processoBat;
        private Process _processoFiveM;

        public BatCheckerThread(Process processoBat, Process processoFiveM)
        {
            _processoBat = processoBat;
            _processoFiveM = processoFiveM;
        }

        public void Job()
        {
            var processoExiste = ProcessoEstaAtivo(_processoBat);

            if (!processoExiste)
                _processoFiveM.Kill();
        }

        private bool ProcessoEstaAtivo(Process processo)
        {
            if (processo != null)
            {
                Process[] processlist = Process.GetProcesses();

                return processlist.FirstOrDefault(pr => pr.Id == processo.Id) != null
                    && processlist.Where(x => x.Id == processo.Id).Count() > 0;
            }
            else
            {
                return false;
            }
        }

    }
}
