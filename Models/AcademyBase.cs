using System;

namespace AspIron.Models
{
    /// <summary>
    /// La clase es abstracta: Podemos heredar de ella pero no
    /// podemos crear instancias de ella
    /// </summary>
    public abstract class AcademyBase
    {
        public string Nombre { set; get; }
        public string UniqueId { private set; get; }

        public AcademyBase() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}