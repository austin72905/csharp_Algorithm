using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace balabla
{
    class Program
    {
        static void Main(string[] args)
        {
            //two sum
            //int[] numsArr = new int[] { 1, 2, 3, 4, 5 };
            //int target = 7;

            //var answer= new Solution().TwoSum(numsArr, target);
            //Console.WriteLine($"[{answer[0]},{answer[1]}]");

            //Reverse
            //int input =1534236469;
            //var answer = new Solution().Reverse(input);
            //Console.WriteLine(answer);
            //Console.Read();

            //Palindrome Number
            //int input = -10;
            //var answer= new Solution().IsPalindrome(input);
            //Console.WriteLine(answer);
            //Console.Read();

            //string input = "XCIX";
            //var answer = new Solution().RomanToInt(input);
            //Console.WriteLine(answer);
            //Console.Read();


            //string[] floArr=new string[2] { "aa", "a" };
            //string answer= new Solution().LongestCommonPrefix(floArr);
            //Console.WriteLine(answer);
            //Console.Read();

            //Valid Parentheses
            //string input = "(){}}{";
            //var answer = new Solution().IsValid(input);
            //Console.WriteLine(answer);
            //Console.Read();

            //Remove Duplicates from Sorted Array
            //int[] nums = new int[] { 0, 0, 0, 1, 1, 1, 2, 3 };
            //var answer = new Solution().RemoveDuplicates(ref nums);
            //Console.WriteLine(answer);
            //Console.Read();

            //string a = "1011";
            //string b = "1";
            //var answer = new Solution().AddBinaryDie(a, b);
            //Console.WriteLine(answer);
            //Console.Read();

            //var digits = new int[] { 9, 9, 9 };
            //var answer = new Solution().PlusOne(digits);
            //Console.WriteLine(answer);
            //Console.Read();


            //var answer = new Solution().ClimbStairs(5);
            //Console.WriteLine(answer);
            //Console.Read();


            //int[] candidates = new int[] { 2, 3, 5 };
            //int target = 8;
            //var answer = new SolutionM().CombinationSum(candidates, target);
            //Console.WriteLine(answer);
            //Console.Read();

            


        }
    }


    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var answer = new int[2];


            var answerNum = 0;


            for (var i = 0; i < nums.Length; i++)
            {
                answerNum = target - nums[i];

                int j = 0;
                while (j < nums.Length)
                {
                    //自己要跳過
                    if (j == i)
                    {
                        j++;
                        continue;
                    }

                    if (answerNum == nums[j])
                    {
                        answer[0] = j;
                        answer[1] = i;
                        break;
                    }

                    j++;
                }


            }

            return answer;
        }

        //Reverse
        public int Reverse(int x)
        {
            string numStr = x.ToString();
            int answer = 0;
            string[] numStrArr = new string[numStr.Length];
            for (int i = 0; i < numStrArr.Length; i++)
            {
                numStrArr[i] = numStr.Substring(i, 1);
            }



            if (numStrArr[0] == "-")
            {
                Array.Reverse(numStrArr, 1, numStrArr.Length - 1);
            }
            else
            {
                Array.Reverse(numStrArr, 0, numStrArr.Length);
            }

            string anserStr = string.Join("", numStrArr);
            anserStr.Replace("0", "");
            //溢位要返回0 = =
            long temp = long.Parse(anserStr);
            if (temp > int.MaxValue || temp < int.MinValue)
            {
                return 0;
            }
            answer = (int)temp;


            return answer;
        }

        //Palindrome Number
        public bool IsPalindrome(int x)
        {
            //輸入的數字轉字串
            //用numArr陣列 接收 假設陣列有n個元素 、len陣列長度
            //比對numArr[n]、numArr[len-1-n] 的值是否相等

            string input = x.ToString();
            string[] numArr = new string[input.Length];
            for (var i = 0; i < numArr.Length; i++)
            {
                numArr[i] = input.Substring(i, 1);
            }

            for (var i = 0; i < numArr.Length; i++)
            {
                if (numArr[i] != numArr[numArr.Length - 1 - i])
                {
                    return false;

                }
            }

            return true;
        }

        //Palindrome Number
        public int RomanToInt(string s)
        {
            //XCIX =>99
            //   4   、   9   、   40   、   90   、   400   、   900
            //  IV       IX       XL        XC        CD         CM

            //scan 輸入的字串 
            //兩個一起scan
            //宣告一個answer
            //I = 1
            //V = 5
            //X = 10
            //L = 50
            //C = 100
            //D = 500
            //M = 1000
            int answer = 0;
            var indexList = new List<int>();
            for (var i = 0; i < s.Length - 1; i++)
            {
                switch (s.Substring(i, 2))
                {
                    case "IV":
                        answer += 4;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;
                    case "IX":
                        answer += 9;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;
                    case "XL":
                        answer += 40;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;
                    case "XC":
                        answer += 90;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;
                    case "CD":
                        answer += 400;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;
                    case "CM":
                        answer += 900;
                        indexList.Add(i);
                        indexList.Add(i + 1);
                        break;

                }
            }

            int x = 0;

            while (x < s.Length)
            {
                var isExisted = indexList.Exists(o => o == x);

                if (isExisted)
                {
                    x++;
                    continue;
                }

                switch (s.Substring(x, 1))
                {
                    case "I":
                        answer += 1;
                        break;
                    case "V":
                        answer += 5;
                        break;
                    case "X":
                        answer += 10;
                        break;
                    case "L":
                        answer += 50;
                        break;
                    case "C":
                        answer += 100;
                        break;
                    case "D":
                        answer += 500;
                        break;
                    case "M":
                        answer += 1000;
                        break;

                }
                x++;
            }


            return answer;
        }

        //Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            //["flower","flow","flight"]
            //以第一個元素比較
            //兩層迴圈 (內層)1. 比較每個元素  (外層)2. 每個元素的字元
            //跳出 1. 當第一個元素的字元>元素的字元
            //迴圈的思考要相反

            string answer = "";

            if (strs.Length == 0)
            {
                return answer;
            }

            if (strs.Length == 1)
            {
                answer = strs[0];
                return answer;
            }



            int oneLen = strs[0].Length;
            var temp = "";
            bool isSame = true;

            //比較第一個元素的每個字元

            for (int i = 0; i < oneLen; i++)
            {


                //先跑每個元素的第i字元
                for (int j = 1; j < strs.Length; j++)
                {
                    //第j個元素的長度

                    //flow 4  j=1
                    //flight 5 j=2
                    int valLen = strs[j].Length;

                    //i 是第一個元素的索引
                    if (i >= valLen)
                    {
                        isSame = false;
                        break;
                    }

                    //第一個元素的第i字元
                    //f
                    temp = strs[0].Substring(i, 1);

                    //每個元素的第i字元
                    //f j=1
                    //f j=2
                    var eachChar = strs[j].Substring(i, 1);


                    if (temp != eachChar)
                    {

                        return answer;
                    }

                }

                //比較完每個元素的第i個字元
                if (isSame)
                {
                    answer += temp;
                }


            }

            return answer;


        }

        //Valid Parentheses
        public bool IsValid(string s)
        {
            //只會傳入()[]{} 這幾個記號 ，必須是成雙成對的才返回true
            //ex: {[]()}
            //思路: 從最裡面開始找
            //運用stack "先進後出"的特性 ，把只要是 "左括號" 的丟入 stack
            //stack的 top 就會是"最裡面"的左括號
            //如果找到"右括號" 看能不能跟 top 配對，如果可以就pop掉

            //如果發現stack 是空的 ，但找到的是"右括號"，代表沒辦法配對，返回false

            //返回true 的條件: stack 是空的，代表都有配對到了

            //因為只會傳右、左括號，可以用dic 來存放

            //如果s 是 奇數，一定不會成雙，return false

            if (s.Length % 2 != 0)
            {
                return false;
            }


            Dictionary<char, char> inputDic = new Dictionary<char, char>();
            inputDic.Add('}', '{');
            inputDic.Add(')', '(');
            inputDic.Add(']', '[');



            var sStack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                char unit = s[i];

                //如果是"左括號"，就加入stack
                //value都是左括號
                if (inputDic.ContainsValue(unit))
                {
                    sStack.Push(unit);
                }
                else
                {
                    //如果不是，肯定是右括號
                    //如果發現stack 是空的 ，但找到的是"右括號"，代表沒辦法配對，返回false
                    if (sStack.Count == 0)
                    {
                        return false;
                    }


                    //先進後出，會從最裡面的左括號，開始配對
                    //()[]{}
                    //這種馬上就遇到右括號的，馬上就被配對掉了，所以沒差
                    //看能不能跟 top 配對，如果可以就pop掉
                    if (sStack.Peek() == inputDic[unit])
                    {
                        sStack.Pop();

                    }
                    else
                    {

                        return false;
                    }

                }
            }

            //歷遍完s，返回true 的條件: stack 是空的，代表都有配對到了

            return sStack.Count == 0;


        }

        //Merge Two Sorted Lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //            1->2->4
            //L1     node1 -> node1.next 

            //            1->3->4
            //L2     node2 -> node2.next 

            //排序兩個link list

            //從小排到大

            //宣告一個方法MergeTwoLists，從頭節點比較，比較l1 、l2 兩個節點誰的值大 ， 
            //返回 值 比較小的節點，讓 比較後"較小"的節點  下一個指向他

            //如果節點下一個指向null ，代表已經到最尾了，就返回另一個


            //如果l1 、l2 都傳null 回傳null
            if (l1==null && l2== null)
            {
                return null;
            }

            //指向尾節點
            //因為會把 下一個節點傳進去， 所以可以這樣比較
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }


            //比較傳入的節點值哪個比較大
            //把比較小的值的下一個傳入，繼續比較 
            if (l1.val <= l2.val)
            {
                //排序小=>大
                //所以最小的下一個節點會指向比較後較小的值
                l1.next = MergeTwoLists(l1.next,l2);

                //返回比較小的那一個
                return l1;
            }
            else
            {
                //l1 > l2 ，把l2的下一個傳入和l1比較，
                //所以最小的下一個節點會指向比較後"較小"的值
                l2.next = MergeTwoLists(l1, l2.next);

                return l2;


            }




        }

        //Remove Duplicates from Sorted Array
        public int RemoveDuplicates(ref int[] nums)
        {
            //限制只能在原本的陣列操作
            //可以在內部對傳入的陣列進行操作
            //最後回傳的值是這個陣列的長度

            //傳入的會是一個排序過的陣列
            //[0,0,0,1,1,1,2,3]

            //宣告一個temp 變數 存放 歷遍到的值  (初始值 temp=nums[0])
            //宣告一個 insertPtr 來表示要插入的位置  (初始值 insertPtr=1)
            //歷遍整個陣列 nums，把值放入temp， 
            //當歷遍的值 nums[i] != temp ， 則在insertPtr  的位置插入該值， insertPtr+1， temp=nums[i]

            //最後return insertPtr ()

            //如果傳入的陣列長度<=1 就值接回傳陣列的長度

            if (nums.Length <= 1)
            {
                return nums.Length;
            }

            int temp = nums[0];
            int insertPtr = 1;

            //歷遍整個陣列 nums
            for(var i=0;i<nums.Length; i++)
            {
                if(nums[i] != temp)
                {
                    nums[insertPtr] = nums[i];
                    insertPtr++;
                    temp = nums[i];
                }
            }

            return insertPtr;

        }

        //Remove Element
        public int RemoveElement(int[] nums, int val)
        {
            //Given nums = [3,2,2,3], val = 3,
            //移除 陣列裡所有  val 的值
            //返回新的陣列長度
            //該陣列的前幾個元素 是剩下沒被刪除的
            //限制: 只能在同個陣列操作

            //宣告變數insertPtr (初始值=0) 代表要插入值的位置
            //歷遍陣列nums  
            //當遍歷到的值 != val ( nums[i] != val) ， 從最前面開始插入值 (nums[insertPtr] =nums[i])  insertPtr+1

            //最後return insertPtr (因為迴圈裡有+1，所以可以當作陣列長度)

            //給的陣列是null 返回 0
            //如果給的陣列長度1 ，其值剛好等於val

            //如果val 都不在陣列裡 (代表什麼都沒刪到) ，值接返回原本的陣列長度
            //宣告一個flag 判斷是否 val 是存在於 陣列nums的值

            //start
            //給的陣列是null 返回 0
            if (nums.Length == 0 )
            {
                
                return nums.Length;
            }

            //nums  [1]   val = 1

            if (nums.Length == 1)
            {
                if (nums[0] == val)
                {
                    nums = null;
                    return 0;
                }
                else
                {
                    return nums.Length;
                }
            }
            

            int insertPtr = 0;
            //宣告一個flag 判斷是否 val 是存在於 陣列nums的值
            bool flag = false;

            for(var i=0;i<nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[insertPtr] = nums[i];
                    flag = true;
                    insertPtr++;
                }
            }

            
            if (flag)
            {
                return insertPtr;
            }

            //如果val 都不在陣列裡 (代表什麼都沒刪到) ，值接返回原本的陣列長度

            //nums [3,3]   val = 3  的情形
            if(nums[0] == val)
            {
                nums = null;
                return 0;
            }

            return nums.Length;

        }

        //Add Binary//二進制 => 十進制 input 最多會到1萬位
        //會有溢位的問題 ，目前是用BigInteger解決
        public string AddBinaryDie(string a, string b)
        {

            //二進制 => 十進制
            //從最小位，*2(從0次方開始)，求和
            //ex: (二進制)1011 = 1*2^0 + 1*2^1 + 0*2^2 + 1*2^3 = (十進制)11

            //十進制 => 二進制
            //該數不斷除以2 直到 商為0 然後將 得到的餘數 ，由下往上排
            //ex (十進制) 56 =>(二進制)111000   ..自己用手算
            //56/2=28...0
            //28/2=14...0
            //14/2=7...0
            //7/2=3...1
            //3/2=1...1
            //1/2=0...1


            //將a、b都轉成10進制，相加之後，在轉回2進制
            //假設 a=1011
            //十進制=11

            string[] numArr = new string[a.Length];
            string[] numArrb = new string[b.Length];
            BigInteger aInt=0;
            BigInteger bInt = 0;
          
            for(var i=0;i<a.Length; i++)
            {

                var multiplier = BigInteger.Pow(2, a.Length-1-i);
                aInt += BigInteger.Parse(a.Substring(i,1)) * multiplier;
            }

            for (var i = 0; i < b.Length; i++)
            {

                var multiplier = BigInteger.Pow(2, b.Length - 1 - i);
                bInt += BigInteger.Parse(b.Substring(i,1)) * multiplier;
            }


            //將二進制轉乘十進制
            BigInteger plus = aInt + bInt;
            //商數
            BigInteger quotient = 0;
            //餘數
            BigInteger last = 0;
            
           
            var answerStack = new Stack<string>();
            while (true)
            {
                //商數
                quotient = plus / 2;
                //餘數
                last = plus - (quotient * 2);
                if (quotient == 0)
                {
                    answerStack.Push(last.ToString());
                    break;
                }
                else
                {
                    answerStack.Push(last.ToString());

                }
                plus = quotient;

            }





            return string.Join("", answerStack);



        }

        //Plus One
        public int[] PlusOne(int[] digits)
        {
            //從最後一位加1
            //先轉成int 會有溢位問題
            //一個元素一個元素操作比較好
            int i = digits.Length - 1;
            int temp = 0;
            //最後一位+1
            digits[digits.Length - 1] = digits[digits.Length - 1] + 1;

            while (digits[i] >= 10)
            {
                //如果該位+1>=10  該位變0，下一位+1
                digits[i] = 0;

                //該位相加完>10，又到了最高位，代表要進位了
                if (i == 0)
                {
                    //這個方法沒有比新建一個array快
                    //Array.Resize(ref digits, digits.Length + 1);

                    //digits[0] = 1;
                    //return digits;

                    //新建一個arr
                    int[] newPos = new int[digits.Length+1];
                    newPos[0] = 1;
                    //這種需要多一位的 都是在 999 ,9999 
                    //前面code已經讓他都變0了，只要讓首位+1即可
                    //for(var a=1;a< newPos.Length; a++)
                    //{
                    //    newPos[a] = digits[a - 1];
                    //}


                    return newPos;
                }
                digits[i - 1] = digits[i - 1] + 1;
                i--;

                if (i < 0)
                {
                    break;
                }

            }

            return digits;
        }

        //Maximum Depth of Binary Tree
        public int MaxDepth(TreeNode root)
        {
            int depth = 0;
            //這樣是算有幾個節點
            //if (root != null)
            //{
            //depth += 1;
            //depth += MaxDepth(root.left);
            //depth+= MaxDepth(root.right);
            //}

            //如果根結點不為null， 深度 = 左右子數 的深度"最大值"+1 (加入根結點)

            if (root != null)
            {
                depth += 1;
                depth += Math.Max(MaxDepth(root.left), MaxDepth(root.right));
            }

            return depth;
        }
        
        //Single Number
        public int SingleNumber(int[] nums)
        {
            //陣列每個元素 不是出現2次  就是 1 次 ，找出只出現一次的元素
            //用一個空list
            //只要不存在nums裡的元素，就丟進去
            //如果存在nums裡的元素，就刪掉
            //最後取list[0]

            var numList = new List<int>();

            for (var i=0;i<nums.Length; i++)
            {
                if (!numList.Contains(nums[i]))
                {
                    numList.Add(nums[i]);
                }
                else
                {
                    numList.Remove(nums[i]);
                }
                
            }

            return numList[0];
        }

        //Climbing Stairs
        public int ClimbStairs(int n)
        {
            //難
            //直接找規律比較快
            //用遞迴效率差，改使用迴圈
            //爬階梯 一次只爬2 or 1 請問有幾種組合
            //n=1     1
            //n=2     2
            //n=3     3
            //n=4     5
            //n=5     8
            //n=6     13
            //n=7     21
            //n=8     34

            //規律:   每個結果都是前兩個結果的相加
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            int answer = 0;
            int prev2 = 1;
            int prev1 = 2;


            //因為1、2不用算，所以從2開始迴圈
            for(var i=2;i<n; i++)
            {
                answer = prev2 + prev1;
                prev2 = prev1;
                prev1 = answer;
            }

            return answer;

        }

        //Implement strStr()
        public int StrStr(string haystack, string needle)
        {
            //找出參數字串所在的位置
            if(needle== "" || needle == null)
            {
                return 0;
            }else if(haystack == null)
            {
                return -1;
            }

            return haystack.IndexOf(needle);

        }


        //Range Sum of BST
        int answer = 0;
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            //歷遍二叉樹，所有的值
            //計算在L、R之間值的總和

            //二叉樹 特性: 左子樹會比中間的小
            //当前节点的所有左子树的值都比他小, 且我们知道这棵树中没有重复值, 那么久没必要将他的左子树再进行递归判断了, 右子树同理
            //每個節點的值都不一樣
            //Input: root = [10, 5, 15, 3, 7, null, 18], L = 7, R = 15
            //el : 10,15,7
            //Output: 32


            if (root == null)
            {
                return 0;
            }

            //歷遍左子樹
            //左子樹一定比當前節點還要小，所以只要他的最小值比L大才要遞迴，
            if (root.val > L && root.left !=null)
            {
                RangeSumBST(root.left,L,R);
            }


            if (root.val >= L && root.val <= R)
            {
                answer += root.val;
            }

            //歷遍右子樹
            //右子樹一定比當前節點要大，所以只要他的最大值比R小才要遞迴，
            if (root.val < R&& root.right != null)
            {
                RangeSumBST(root.right, L, R);
            }

            return answer;




        }

        //Same Tree
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            string str = "";
            string str2 = "";
            Peorder(p,ref str);
            Peorder(q, ref str2);

            return str == str2;

        }
        //Same Tree
        public void Peorder(TreeNode root,ref string str)
        {
            if (root != null)
            {
                
                str += root.val;
                Peorder(root.left, ref str);

                Peorder(root.right, ref str);
            }
            else
            {
                //root == null 就打個0標示一下，確保 [1,2] [1,null,2] 打出來的字串不一樣
                str += 0;
            }
        }

        //[60, 25, 93, 34, 18, 79]






    }

    //Merge Two Sorted Lists
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    //Maximum Depth of Binary Tree
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }



}
