**Accounting contract to handle money transactions in relation to energy exchange (delivery). **

In general a *Stromkonto* is a set of accounting rules allowing a single owner to manage transactions between different addresses. Each transaction consists of a *from*,*to*,*base*,*value* whicht will effect the balances accordingly.

As the native Stromkonto contract only allows one sender of transactions, there is a proxy to this which allows mutiple transaction origins to be approved [StromkontoProxy](./stromkontoproxy.html). 
