using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1797. 设计一个验证系统
    /// </summary>
    public class AuthenticationManager
    {
        readonly Dictionary<string, int> _token;
        readonly int _timeToLive;
        public AuthenticationManager(int timeToLive)
        {
            _timeToLive = timeToLive;
            _token = new();
        }

        public void Generate(string tokenId, int currentTime)
        {
            _token[tokenId] = currentTime;
        }

        public void Renew(string tokenId, int currentTime)
        {
            if (_token.ContainsKey(tokenId))
            {
                if (currentTime < _token[tokenId] + _timeToLive) _token[tokenId] = currentTime;
            }
        }

        public int CountUnexpiredTokens(int currentTime)
        {
            List<string> overdueTokens = new();

            foreach (var token in _token)
            {
                if (currentTime >= token.Value + _timeToLive) overdueTokens.Add(token.Key);
            }

            overdueTokens.ForEach(key => _token.Remove(key));

            return _token.Count;
        }
    }
}