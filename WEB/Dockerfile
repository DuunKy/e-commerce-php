# Apache image tag
FROM httpd:2.4
WORKDIR /usr/local/apache2/htdocs/
COPY web.conf /usr/local/apache2/conf/web.conf

RUN echo "Include /usr/local/apache2/conf/web.conf" \
    >> /usr/local/apache2/conf/httpd.conf