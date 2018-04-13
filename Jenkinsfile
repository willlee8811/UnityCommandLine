pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('BuildPC') {
          steps {
            echo 'Build'
            sh '''#!/bin/bash
 
UNITY_PATH="D:\\Unity\\Editor\\Unity.exe"
PROJECT_PATH="C:\\Program Files (x86)\\Jenkins\\workspace\\UnityCommandLine_master-6QYLZI6LZO7LZ4X2BCK6XHHK3NUXXXK3LPPOAGPXHVBBGKGOBB2Q\\UnityCommandLineBuild-master"
BUILD_LOG_PATH="${PROJECT_PATH}\\build.log"
DESTINATION_PATH="C:\\Program Files (x86)\\Jenkins\\workspace\\UnityCommandLine_master-6QYLZI6LZO7LZ4X2BCK6XHHK3NUXXXK3LPPOAGPXHVBBGKGOBB2Q\\UnityCommandLineBuild-master"

"$UNITY_PATH" -projectPath "$PROJECT_PATH" -logFile "$LOG_PATH"  -quit -batchmode -executeMethod BuildTool.Build'''
          }
        }
        stage('Bat') {
          steps {
            bat 'ECHO finish'
          }
        }
      }
    }
    stage('Finish') {
      steps {
        echo 'Finish'
      }
    }
  }
}