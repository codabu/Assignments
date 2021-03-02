var gulp = require('gulp');
var git = require('gulp-git');

// Run git add
gulp.task('add', function(done){
    return gulp.src('./*')
      .pipe(git.add(done));
  });

  // Run git commit
gulp.task('commit', function(){
    return gulp.src('./*')
      .pipe(git.commit('initial commit'));
  });

  //Run git push
  gulp.task('push', function(){
    git.push('origin', 'master', function (err) {
      if (err) throw err;
    });
  });

  gulp.task('helloworld', function(done){
    console.log('HelloWorld');
    done();
  });