using System.Collections.Generic;

namespace Aruru.Course
{
    public class Kyoto : ICourse
    {
        public string Name { get; } = "京都";
        public string ID { get; } = "KT";
        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1400, 1600, 1800, 2000, 2200, 2400, 3000, 3200
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1200, 1400, 1800, 1900
            };
            return list;
        }
    }
}
