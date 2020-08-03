FROM ikemtz/sql_dacpac:latest as sql-temp
ENV SA_PASSWORD=SqlDockerRocks123! \
    ACCEPT_EULA=Y

#Copy dacpacs
COPY /src/inventory/IkeMtz.Mechanager.Inventory.Db/bin/Debug/*.dacpac /dacpac/

RUN /opt/mssql/bin/sqlservr & sleep 20 \
    && sqlpackage /Action:Publish /TargetServerName:localhost /TargetUser:SA /TargetPassword:$SA_PASSWORD /SourceFile:/dacpac/ivtrDb.dacpac /TargetDatabaseName:ivtrDb /p:BlockOnPossibleDataLoss=false \
    \
    && sqlpackage /Action:Publish /TargetServerName:localhost /TargetUser:SA /TargetPassword:$SA_PASSWORD /SourceFile:/dacpac/ivtrDb.dacpac /TargetDatabaseName:mechanager /p:BlockOnPossibleDataLoss=false \
    \
    && sleep 20 \
    && pkill sqlservr && sleep 10 \
    && sudo rm -rf /dacpac

FROM mcr.microsoft.com/mssql/server
LABEL author="@IkeMtz"
ENV SA_PASSWORD=SqlDockerRocks123! \
    ACCEPT_EULA=Y
EXPOSE 1433
COPY --from=sql-temp /var/opt/mssql/data/ /var/opt/mssql/data/

USER root
RUN chown -R mssql /var/opt/mssql/data
USER mssql
