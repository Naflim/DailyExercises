using System.Collections.Generic;
using System.Xml.Linq;

namespace DailyExercises
{
    public class MKAverage
    {
        private int _m, _k, _standard;
        private Queue<int> _elements;
        private SortedDictionary<int, long> _dictionary;
        private readonly bool _isMeaningless;
        private bool _canRefresh;
        private int _average;

        public MKAverage(int m, int k)
        {
            _m = m;
            _k = k;
            _standard = _m - _k * 2;
            _isMeaningless = _standard <= 0;
            _elements = new Queue<int>();
            _dictionary = new SortedDictionary<int, long>();
        }

        public void AddElement(int num)
        {
            if (_isMeaningless) return;

            if (_elements.Count >= _m)
            {
                int n = _elements.Dequeue();
                if (_dictionary[n] > 1) _dictionary[n]--;
                else _dictionary.Remove(n);
            }
            _elements.Enqueue(num);
            if (_dictionary.ContainsKey(num)) _dictionary[num]++;
            else _dictionary[num] = 1;

            _canRefresh = true;
        }

        public int CalculateMKAverage()
        {
            if (_elements.Count < _m) return -1;
            else if (_isMeaningless) return 0;
            else
            {
                if (_canRefresh)
                {
                    long count = -_k;
                    long sum = 0;

                    foreach (var item in _dictionary)
                    {
                        if(count < 0)
                        {
                            if (item.Value > -count)
                            {
                                long n = item.Value + count;
                                if (n <= _standard) sum += n * item.Key;
                                else
                                {
                                    sum += _standard * item.Key;
                                    break;
                                }

                            }
                            count += item.Value;
                        }
                        else
                        {
                            if(_standard - count >= item.Value) 
                            {
                                sum += item.Value * item.Key;
                                count += item.Value;
                            }
                            else
                            {
                                sum += (_standard - count) * item.Key;
                                break;
                            }
                        }

                        if (count == _standard) break;

                    }

                    _average = (int)(sum / _standard);

                    _canRefresh = false;
                }

                return _average;
            }
        }
    }

    //public class MKAverage
    //{
    //    private int _m, _k, _addCount, _standard, _minNum;
    //    private SortedDictionary<int, int> _elements;
    //    private readonly bool _isMeaningless;

    //    public MKAverage(int m, int k)
    //    {
    //        _m = m;
    //        _k = k;
    //        _standard = _m - _k * 2;
    //        _isMeaningless = _standard <= 0;
    //        _elements = new SortedDictionary<int, int>();
    //    }

    //    public void AddElement(int num)
    //    {
    //        if(_isMeaningless) return;

    //        if (_addCount >= _m)
    //        {
    //            if (num > _minNum)
    //            {
    //                var first = _elements.First();
    //                if (_elements.ContainsKey(num)) _elements[num]++;
    //                else _elements[num] = 1;

    //                if (first.Value > 1) _elements[first.Key]--;
    //                else
    //                {
    //                    _elements.Remove(first.Key);
    //                    _minNum =  _elements.First().Key;
    //                }

    //            }
    //        }
    //        else
    //        {
    //            if (_elements.ContainsKey(num)) _elements[num]++;
    //            else _elements[num] = 1;

    //            if (_addCount == _m - 1) _minNum = _elements.First().Key;
    //        }

    //        _addCount++;
    //    }

    //    public int CalculateMKAverage()
    //    {
    //        if (_addCount < _m) return -1;
    //        else if (_isMeaningless) return 0;
    //        else
    //        {

    //            int[] nums = new int[_m];

    //            int index = 0;
    //            foreach (var element in _elements) 
    //            {
    //                for (int i = 0; i < element.Value; i++)
    //                {
    //                    nums[index] = element.Key;
    //                    index++;
    //                }
    //            }

    //            return nums.Skip(_k).Take(_standard).Sum()/_standard;
    //        }
    //    }
    //}

}
