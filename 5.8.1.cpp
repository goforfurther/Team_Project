#include<cstdio>
#include<cstring>
#include<stack>
#include<algorithm>
#include<queue>
using namespace std;
queue<int> q;
int main()
{
	int n;scanf("%d",&n);
	while(n--)
	{
		int pro;
		scanf("%d",&pro);
		if(pro==1)
		{
			int a;
			scanf("%d",&a);
			q.push(a);
		}
		else if(pro==2)
		{
			printf("%d\n",q.front()*131);
			q.pop();
		}
		else if(pro==3)
		{
			printf("%d\n",q.front()*121);
			q.pop();
		}
		else if(pro==4)
		{
			printf("%d\n",q.size());
		}
	}
	return 0;
}

