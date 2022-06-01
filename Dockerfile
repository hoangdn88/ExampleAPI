FROM nginx:latest

#CMD echo "Xin chào Đỗ Ngọc Hoàng"

# Update the repository
#RUN sudo apt-get update
# Install necessary tools
#RUN apt-get install -y nano wget dialog net-tools vim git

#Thiết lập thư mục hiện tại
WORKDIR /var/www/html

# Remove file index docker
RUN rm -rf /var/www/html/index.html
#RUN rm /etc/nginx/conf.d/default.conf

# Copy tất cả các file trong thư mục hiện tại (.)  vào WORKDIR
#ADD index.nginx-debian.html /var/www/html
#COPY nginx.conf /etc/nginx/conf.d/default.conf

#COPY index.html /usr/share/nginx/html/index.html
COPY index.html /var/www/html/index.html

VOLUME /var/www/html/

#Thiết lập khi tạo container từ image sẽ mở cổng 80
# ở mạng mà container nối vào
EXPOSE 80 443

# Khi chạy container tự động chạy ngay httpd
#ENTRYPOINT ["/usr/sbin/httpd"]

#chạy terminate
CMD [ "nginx", "-g", "daemon off;" ]
