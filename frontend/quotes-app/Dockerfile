FROM node:22 AS builder
WORKDIR /app
COPY package*.json ./
RUN npm install -g @angular/cli@20 \
    && npm ci
COPY . .
RUN ng build


FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /app/dist/quotes-app/browser/ /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]