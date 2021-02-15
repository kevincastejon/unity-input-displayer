var ghpages = require('gh-pages');
 
ghpages.publish("./Build", function(err) {console.log(err)});