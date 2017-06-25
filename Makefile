#
# StromDAO Business Object - Documentation
# Deployment via Makefile to automate general Quick Forward 
#

PROJECT = "StromDAO Docs"


all: docs publish

docs: ;cd ./code && \
   node docmaker.js ;
   
publish: ;git add -A && git commit -a -m "Updated Documentation" && git push origin master;
   

