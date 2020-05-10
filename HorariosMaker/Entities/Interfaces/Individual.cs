using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorariosMaker.Entities.Interfaces
{
    public interface Individual
    {
        /// <summary>
        /// Retorna la cantidad de genes que tiene el invidiuo
        /// </summary>
        /// <returns></returns>
        int Size();

        /// <summary>
        /// Retorna un subarreglo de genes que tiene el individuo
        /// </summary>
        /// <param name="fromPosition">Límite inferior inclusivo</param>
        /// <param name="toPosition">Límite superior exclusivo</param>
        /// <returns></returns>
        Individual GetGenSlice(int fromPosition, int toPosition);

        /// <summary>
        /// Anexa los genes de un individuo al final del individuo actual
        /// </summary>
        /// <param name="indivual"></param>
        /// <returns></returns>
        Individual AppendToEnd(Individual indivual);

        /// <summary>
        /// Obtiene un valor aceptable de idoneidad para decirse que cumple con lo indicado
        /// </summary>
        int GetAcceptableSuitability();

        /// <summary>
        /// Intercambia un gen en la posicion indicada
        /// </summary>
        /// <param name="positionToSwap"></param>
        /// <param name="schedule"></param>
        void SwapGen(int positionToSwap, Gen gen);
    }
}
