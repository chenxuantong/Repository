using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDS017.BinarySTreeDemo
{
    /// <summary>
    /// 简单的计算性能计数器
    /// </summary>
    public class PerformanceTimer
    {
        public static readonly bool IsHighPerformance;

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        private long m_startTime;
        private long m_stopTime;
        private static long m_freq;

        static PerformanceTimer()
        {
            try
            {
                IsHighPerformance =
                    QueryPerformanceFrequency(out m_freq);
            }
            catch (Exception)
            {
                IsHighPerformance = false;
            }
        }

        public PerformanceTimer()
        {
            m_startTime = 0;
            m_stopTime = 0;
        }

        /// <summary>
        /// 开始计时
        /// </summary>
        public void Start()
        {

            // 设置等待的线程开始工作
            Thread.Sleep(0);
            if (IsHighPerformance)
            {
                QueryPerformanceCounter(out m_startTime);
            }
            else
            {
                m_startTime = DateTime.Now.Ticks;
            }
        }

        /// <summary>
        /// 停止计时
        /// </summary>
        public void Stop()
        {
            if (IsHighPerformance)
            {
                QueryPerformanceCounter(out m_stopTime);
            }
            else
            {
                m_stopTime = DateTime.Now.Ticks;
            }
        }

        /// <summary>
        /// 以秒为单位返回计时的时间长度
        /// </summary>         
        public double DurationSeconds
        {
            get
            {
                if (IsHighPerformance)
                {
                    return (double)(m_stopTime - m_startTime) /
                        (double)m_freq;
                }
                else
                {
                    TimeSpan span = (new DateTime(m_stopTime)) - (new DateTime(m_startTime));
                    return span.TotalSeconds;
                }
            }
        }
    }
}
