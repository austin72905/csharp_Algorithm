using System;
using System.Collections.Generic;
using System.Text;

namespace balabla
{
    //Combination Sum
    public class SolutionM
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            //心得:
            //1. 如果All elements of candidates are distinct ，可以先"排序" 從頭比對



            //Input: candidates = [2,3,5], target = 8
            //Output:[[2,2,2,2],[2,3,3],[3,5]]

            //All elements of candidates are distinct.

            var result = new List<IList<int>>();

            //每個元素不重複，所以先排序，從最小的開始計算
            Array.Sort(candidates);

            //return empty list
            if(candidates.Length==0 || target < candidates[0])
            {
                return result;
            }
            //使用遞迴
            //sum 初始值帶0進去
            GetSumResult(candidates, target,0,new List<int>(), result);
            return result;



        }
        //Combination Sum
        public void GetSumResult(int[] candidates, int target,int sum, IList<int> res, IList<IList<int>> result)
        {
            
            if(target< sum)
            {
                return;
            }

            //找到結果時，就把組合加進result
            if(target == sum)
            {
                //這邊要加入新的
                result.Add(new List<int>(res));
                return;
            }

            for(int i=0;i<candidates.Length; i++)
            {
                //因為前面排序過了
                //當加到[2,2,2]+3 相加>8
                //會跳出，執行移除最後一個元素 變成 [2,2]
                if (sum + candidates[i] > target)
                {
                    break;
                }

                
                //避免有重複的組合出現
                //round 1 --> res [2,2,3]
                //round 2 --> res [3,2] xx->這個就不會紀錄 
                if(res.Count > 0 && candidates[i] < res[res.Count - 1])
                {
                    continue;
                }


                //遞迴
                //key: 從candidates 第一個元素開始 一直加，直到sum>target 會跳出
                
                res.Add(candidates[i]);
                GetSumResult(candidates, target, sum + candidates[i], res, result);
                //移除最後一個元素，看下一個元素加到sum是否會=target
                res.RemoveAt(res.Count - 1);


            }

        }


        
    }
}
