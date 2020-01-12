using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aruru.Course
{
    interface ICourse {
        string Name { get; }
        string ID { get; }
        List<int> GrassCourse();
        List<int> DirtCourse();
    }
}
