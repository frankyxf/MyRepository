        summary
         对List进行随机排序
         summary
         param name=listTparam
         returnsreturns
        private static ListT RandomSortListT(IEnumerableT listT)
        {
            var random = new Random();
            var newList = new ListT();
            foreach (var item in listT)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }