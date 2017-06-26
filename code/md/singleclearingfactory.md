** Factory class to construct a new [SingleClearing](./singleclearing.html) **

Usage:
```javascript
node.singleclearingfactory().then(function(scf) {
  scf.build(...).then(function(address) {
		console.log("Your New SingleClearing is at",address);
  });
});
```

