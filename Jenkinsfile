pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            echo 'Build'
            sh 'sh "echo hello sh"'
          }
        }
        stage('Bat') {
          steps {
            bat 'ECHO finish'
          }
        }
      }
    }
    stage('Unity') {
      steps {
        echo '"$UNITY_PATH" -projectPath "$PROJECT_PATH" -logFile "$LOG_PATH"  -quit -batchmode -executeMethod BuildTool.Build'
      }
    }
  }
}