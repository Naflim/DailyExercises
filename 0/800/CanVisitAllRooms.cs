using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 841. 钥匙和房间
    /// </summary>
    internal class CanVisitAllRooms
    {
        public static bool Run(IList<IList<int>> rooms)
        {
            RoomNode origin = new RoomNode(rooms, 0);
            Graph<RoomNode> graph = new Graph<RoomNode>(origin);
            graph.StartRetrieval();
            return graph.Count() == rooms.Count;
        }
    }

    public class RoomNode:IGraphNode<RoomNode>
    {
        private IList<IList<int>> rooms;

        public RoomNode(IList<IList<int>> rooms, int id)
        {
            this.rooms=rooms;
            Id=id;
        }

        public int Id { get; }

        public RoomNode[] GetNextNodes()
        {
            var keys = rooms[Id];
            return keys.Select(k => new RoomNode(rooms,k)).ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is RoomNode node)
            {
                return node.Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
