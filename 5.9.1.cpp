#include<cstdio>
#include<cstring>
#include<stack>
#include<algorithm>
#include<queue>
using namespace std;
int main()
{
	int a,L=0,R=0;char s[100000+5];
	scanf("%d%s",&a,s);
	for(int i=0;i<a;i++)
	{
		if(s[i]=='(')L++;
		if(s[i]==')')R++;
	}
	if(L==R)printf("YES");
	else printf("NO");
	return 0;
}
