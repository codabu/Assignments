var gulp = require('gulp');
var git = require('gulp-git');

// Run git add
gulp.task('add', function(done){
    return gulp.src('./*')
      .pipe(git.add(done));
  });

  // Run git commit
gulp.task('commit', function(done){
    return gulp.src('./*')
      .pipe(git.commit('initial commit'));
    done();
  });

  //Run git push
  gulp.task('push', function(done){
    git.push('origin', 'master', function (err) {
      if (err) throw err;
    });
    done();
  });

  gulp.task('helloworld', function(done){
    console.log('HelloWorld');
    done();
  });