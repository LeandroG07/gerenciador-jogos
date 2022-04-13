FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=@gerenciadorjogos123

EXPOSE 6060

COPY ./scripts /db/

ENTRYPOINT [ "/bin/bash", "/db/entrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]