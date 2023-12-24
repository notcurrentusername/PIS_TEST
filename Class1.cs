using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace L4VP
{

    class ListItem<T>
    {
        //мой код start///////////////////////////////////////////////////
        private int hours;
        private int minutes;
        private int seconds;

        public int getHours() { return this.hours; }
        public int getMinutes() { return this.minutes; }
        public int getSeconds() { return this.seconds; }
        public void setHours(int h) { this.hours = h; }
        public void setMinutes(int m) { this.minutes = m; }
        public void setSeconds(int s) { this.seconds = s; }

        // Метод, возвращающий полное количество секунд
        public int GetTotalSeconds()
        {
            return hours * 3600 + minutes * 60 + seconds;
        }

        // Метод, возвращающий полное количество минут
        public int GetTotalMinutes()
        {
            return hours * 60 + minutes;
        }

        //мой код end////////////////////////////////////////////////////
        public T Data { get; set; } //Данные для хранения
        public ListItem<T> Next { get; set; } //Указатель на следующий элемент

        public ListItem(T item)
        {
            this.Data = item;
        }
    }

    interface poper
    {
        void Pop();
    }

    interface pusher<T>
    {
        void Push(T item);  
    }

    class GenericLIFO<T>:poper,pusher<T>
    {
        ListItem<T> Top { get; set; }

        private int length = 0;
        public int Length {
            get {

                return this.length;

                }

            set { }
        }

        public void Push(T item) //Добавление элемента в список
        {
            ListItem<T> I = new ListItem<T>(item);

            if (Top == null)
            {
                I.Next = null;
            }
            else
            {
                I.Next = Top;

            }
            Top = I;
            length++;
        }

        public void Pop( ) //Удаление элемента из списка
        {
            if (Top == null)
            {
                
            }
            else
            {
                Top = Top.Next;
                length--;
            }
            
        }

        public T Get (int i)
        {

            if (i>length)
            {
                return default(T);
            }
            int cur = 1;
            ListItem<T> curc = Top;
            while (cur < i)
            {
                cur++;
                curc = curc.Next;
            }
            return curc.Data;
        }


    }
}   