pipeline {
  agent {
    dockerfile {
      filename 'VNADS'
    }

  }
  stages {
    stage('Build App') {
      steps {
        build(job: 'build VNADS', quietPeriod: 1)
      }
    }
  }
}