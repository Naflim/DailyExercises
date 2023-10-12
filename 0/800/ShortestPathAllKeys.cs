
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 864. 获取所有钥匙的最短路径
    /// </summary>
    internal class ShortestPathAllKeys
    {
        public static int Run2(string[] grid)
        {
            HashSet<char> keys = new HashSet<char>();
            Player? player = null;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var val = grid[i][j];
                    if (val == '@')
                        player = new Player(j, i, string.Empty, 0);
                    else if (char.IsLower(val))
                        keys.Add(val);
                }
            }
            if (player == null)
                return -1;

            Queue<Player> queue = new Queue<Player>();
            queue.Enqueue(player);
            Dictionary<string, HashSet<int[]>> footmark = new Dictionary<string, HashSet<int[]>>
            {
                { string.Empty, new HashSet<int[]>(new NearestExitComparer()) { new int[] { player.Y, player.X } } }
            };

            while(queue.Count > 0)
            {
                var pointer = queue.Dequeue();
                if (pointer.IsTarget(keys))
                    return pointer.StepNumber;

                var nexts = pointer.GetNextStep(grid, footmark);
                foreach (var next in nexts)
                {
                    queue.Enqueue(next);
                }
            }

            return -1;
        }

        public static int Run(string[] grid)
        {
            int keysCount = 0;
            Cell? start = null;
            int gridLen = grid.Length;
            Cell[][] map = new Cell[gridLen][];
            for (int i = 0; i<gridLen; i++)
            {
                int cellLen = grid[i].Length;
                map[i] = new Cell[cellLen];
                for (int j = 0; j<cellLen; j++)
                {
                    map[i][j] = new Cell(grid[i][j], j, i, ref start, ref keysCount);
                }
            }

            List<char> keys = new List<char>();
            if (start is not Cell startPoint || !startPoint.Explore(keys)) return -1;
            return Run(0, new List<Step> { new Step(startPoint, map, keys) }, keysCount);
        }

        public static int Run(int steps, List<Step> sites, int target)
        {
            List<Step> feasibles = new List<Step>();

            foreach (var site in sites)
            {
                var siteFeasibles = Spread(site.Map, site.Now, site.Keys);
                foreach (var feasible in siteFeasibles)
                {
                    if (feasible.Keys.Count == target) return steps + 1;
                    feasibles.Add(feasible);
                }
            }

            steps++;

            if (feasibles.Count == 0) return -1;
            else return Run(steps, feasibles, target);
        }

        public static List<Step> Spread(Cell[][] map, Cell cell, List<char> keys)
        {
            List<Step> feasibles = new List<Step>();
            if (cell.Y != 0)
            {
                var newMap = CopyMap(map);
                Cell top = newMap[cell.Y - 1][cell.X];
                var newKeys = new List<char>();
                newKeys.AddRange(keys);
                if (top.Explore(newKeys)) feasibles.Add(new Step(top, newMap, newKeys));
            }

            if (cell.Y != map.Length - 1)
            {
                var newMap = CopyMap(map);
                Cell bottom = newMap[cell.Y + 1][cell.X];
                var newKeys = new List<char>();
                newKeys.AddRange(keys);
                if (bottom.Explore(newKeys)) feasibles.Add(new Step(bottom, newMap, newKeys));
            }

            if (cell.X != 0)
            {
                var newMap = CopyMap(map);
                Cell left = newMap[cell.Y][cell.X - 1];
                var newKeys = new List<char>();
                newKeys.AddRange(keys);
                if (left.Explore(newKeys)) feasibles.Add(new Step(left, newMap, newKeys));
            }

            if (cell.X != map[cell.Y].Length - 1)
            {
                var newMap = CopyMap(map);
                Cell right = newMap[cell.Y][cell.X + 1];
                var newKeys = new List<char>();
                newKeys.AddRange(keys);
                if (right.Explore(newKeys)) feasibles.Add(new Step(right, newMap, newKeys));
            }

            return feasibles;
        }

        private static Cell[][] CopyMap(Cell[][] map)
        {
            Cell[][] newMap = new Cell[map.Length][];
            for (int i = 0; i<map.Length; i++)
            {
                int cellLen = map[i].Length;
                newMap[i] = new Cell[cellLen];
                for (int j = 0; j<cellLen; j++)
                {
                    newMap[i][j] = map[i][j].Copy();
                }
            }

            return newMap;
        }
    }

    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Keys { get; set; }
        public int StepNumber { get; set; }

        public Player(int x, int y, string keys, int stepNumber)
        {
            X = x;
            Y = y;
            Keys = keys;
            StepNumber = stepNumber;
        }

        public bool IsTarget(HashSet<char> keys)
        {
            return keys.SetEquals(Keys);
        }

        public bool CanWalk(int[] pointer, string[] map, Dictionary<string, HashSet<int[]>> footmark)
        {
            char val = map[pointer[0]][pointer[1]];
            if (val == '#')
                return false;

            if (char.IsUpper(val) && !Keys.Contains((char)(val + 32)))
                return false;

            return !footmark[Keys].Contains(pointer);
        }

        public List<Player> GetNextStep(string[] map, Dictionary<string, HashSet<int[]>> footmark)
        {
            List<Player> list = new List<Player>();

            void AddNextStep(int[] pointer)
            {
                var val = map[pointer[0]][pointer[1]];
                footmark[Keys].Add(pointer);
                if (char.IsLower(val) && !Keys.Contains(val))
                {
                    string newKeys = Keys + val;
                    footmark[newKeys] = new HashSet<int[]>(new NearestExitComparer()) { pointer };
                    list.Add(new Player(pointer[1], pointer[0], newKeys, StepNumber + 1));
                }
                else
                {
                    list.Add(new Player(pointer[1], pointer[0], Keys, StepNumber + 1));
                }
            }

            if (X > 0)
            {
                var newPointer = new int[] { Y, X - 1 };
                if (CanWalk(newPointer, map, footmark))
                {
                    AddNextStep(newPointer);
                }
            }

            if (X < map[0].Length - 1)
            {
                var newPointer = new int[] { Y, X + 1 };
                if (CanWalk(newPointer, map, footmark))
                {
                    AddNextStep(newPointer);
                }
            }

            if (Y > 0)
            {
                var newPointer = new int[] { Y - 1, X };
                if (CanWalk(newPointer, map, footmark))
                {
                    AddNextStep(newPointer);
                }
            }

            if (Y < map.Length - 1)
            {
                var newPointer = new int[] { Y + 1, X };
                if (CanWalk(newPointer, map, footmark))
                {
                    AddNextStep(newPointer);
                }
            }

            return list;
        }
    }

    public class Step
    {
        public Cell Now { get; set; }
        public Cell[][] Map { get; set; }
        public List<char> Keys { get; set; }

        public Step(Cell now, Cell[][] map, List<char> keys)
        {
            Now=now;
            Map=map;
            Keys=keys;
        }
    }


    public class Cell
    {
        public string State
        {
            get { return _state; }
        }

        public char Content { get; }
        public int X { get; }
        public int Y { get; }

        private string _state;


        public Cell(char content, int x, int y, ref Cell? start, ref int keysCount)
        {
            if (content>='a' && content<='z') keysCount++;

            if (content == '@')
            {
                Content = '.';
                start = this;
            }
            else Content = content;
            X=x;
            Y=y;
            _state = "/";
        }

        private Cell(char content, int x, int y, string state)
        {
            Content=content;
            X=x;
            Y=y;
            _state=state;
        }

        public Cell Copy()
        {
            return new Cell(Content, X, Y, State);
        }

        public bool Explore(List<char> keys)
        {
            switch (Content)
            {
                case '.':
                    if (_state== "/")
                    {
                        _state = string.Empty;
                        _state += new string(keys.ToArray());
                        return true;
                    }
                    else
                    {
                        string newKey = string.Empty;

                        keys.ForEach(key =>
                        {
                            if (!_state.Contains(key)) newKey += key;
                        });

                        if (newKey == string.Empty) return false;
                        else
                        {
                            if (keys.Count == 0) _state = string.Empty;

                            _state += newKey;
                            return true;
                        }
                    }
                case '#':
                    return false;
                default:
                    if (Content>='a' && Content<='z')
                    {
                        if (keys.Contains(Content)) return false;
                        else
                        {
                            keys.Add(Content);
                            return true;
                        }
                    }
                    else if (Content >='A' && Content <= 'Z')
                    {
                        char neetKey = (char)(Content + 32);
                        if (keys.Contains(neetKey))
                        {
                            if (_state== "/")
                            {
                                _state = string.Empty;
                                _state += new string(keys.ToArray());
                                return true;
                            }
                            else
                            {
                                string newKey = string.Empty;

                                keys.ForEach(key =>
                                {
                                    if (!_state.Contains(key)) newKey += key;
                                });

                                if (newKey == string.Empty) return false;
                                else
                                {
                                    if (keys.Count == 0) _state = string.Empty;

                                    _state += newKey;
                                    return true;
                                }
                            }
                        }
                        else return false;
                    }
                    else return false;
            }
        }
    }


    //public class Cell
    //{
    //    public int State
    //    {
    //        get { return _state; }
    //    }

    //    public char Content { get; }
    //    public int X { get; }
    //    public int Y { get; }

    //    private int _state;

    //    public Cell(char content, int x, int y, ref Cell? start, ref int keysCount)
    //    {
    //        if (content>='a' && content<='z') keysCount++;

    //        if (content == '@')
    //        {
    //            Content = '.';
    //            start = this;
    //        }
    //        else Content = content;
    //        X=x;
    //        Y=y;
    //        _state = -1;
    //    }

    //    private Cell(char content, int x, int y, int state)
    //    {
    //        Content=content;
    //        X=x;
    //        Y=y;
    //        _state=state;
    //    }

    //    public Cell Copy()
    //    {
    //        return new Cell(Content, X, Y, State);
    //    }

    //    public bool Explore(List<char> keys)
    //    {
    //        switch (Content)
    //        {
    //            case '.':
    //                if (keys.Count == _state) return false;
    //                else
    //                {
    //                    _state = keys.Count;
    //                    return true;
    //                }
    //            case '#':
    //                return false;
    //            default:
    //                if (Content>='a' && Content<='z')
    //                {
    //                    if (keys.Contains(Content)) return false;
    //                    else
    //                    {
    //                        keys.Add(Content);
    //                        return true;
    //                    }
    //                }
    //                else if (Content >='A' && Content <= 'Z')
    //                {
    //                    char neetKey = (char)(Content + 32);
    //                    if (keys.Contains(neetKey))
    //                    {
    //                        if (keys.Count == _state) return false;
    //                        else
    //                        {
    //                            _state = keys.Count;
    //                            return true;
    //                        }
    //                    }
    //                    else return false;
    //                }
    //                else return false;
    //        }
    //    }
    //}
}
