# Apache image tag
FROM httpd:2.4
WORKDIR /usr/local/apache2/htdocs/
COPY WEB-tiny /usr/local/apache2/htdocs/WEB-tiny
EXPOSE 80
CMD ["apachectl", "-D", "FOREGROUND"]