using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProyectoFinal.UWP.Converters
{
    class EndDateConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var endDateValue = (DateTime)value;
            bool vigente = DateTime.Compare(DateTime.Now, endDateValue) <= 0; // Si la fecha y hora actuales son anteriores a la fecha límite, la subasta se encuentra vigente
            if (vigente)
            {
                return endDateValue.ToString("dd MMM yyyy, HH:mm", new CultureInfo("es-ES"));
            }
            return "Finalizado";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
