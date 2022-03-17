pipeline {
    agent any 
    triggers { // https://www.jenkins.io/doc/book/pipeline/syntax/#triggers
        cron("0 1 * * *") // https://en.wikipedia.org/wiki/Cron + https://crontab.guru/
        pollSCM("H * * * *") // https://en.wikipedia.org/wiki/Cron + https://crontab.guru/ 
    }
    stages {
        stage("Building the API") { 
            steps {
                sh "dotnet build TitanMarketBackend/TitanMarket.sln"
            }
        }
        stage("Building the Frontend") {
            steps {
                dir("TitanMarketFrontend")
                 sh "npm install" 
                 sh "npm run-script build" 
            }
        }
        stage ("Test") {
            steps {
                dir("TitanMarketBackend/TitanMarket.Core.Test") { 
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                }
                dir("TitanMarketBackend/TitanMarket.Domain.Test") { 
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                }
            }
            post {
                success {
                    publishCoverage adapters: [coberturaAdapter("TitanMarketBackend/TitanMarket.Core.Test/TestResults/*/coverage.cobertura.xml")]
                    publishCoverage adapters: [coberturaAdapter("TitanMarketBackend/TitanMarket.Domain.Test/TestResults/*/coverage.cobertura.xml")]
                }
            }
        }
     }
}