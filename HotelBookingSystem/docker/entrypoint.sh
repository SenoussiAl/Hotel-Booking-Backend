#!/usr/bin/env bash
set -e


# Wait for Postgres to be ready
HOST="${DB_HOST:-postgres}"
PORT="${DB_PORT:-5432}"


echo "Waiting for Postgres at $HOST:$PORT..."


# wait loop using bash built-in TCP connection
until (echo > /dev/tcp/$HOST/$PORT) >/dev/null 2>&1; do
printf '.'
sleep 1
done


echo "Postgres is available — starting the app"


# Start the application (the CMD will run dotnet HotelBookingSystem.dll as fallback)
exec "$@"